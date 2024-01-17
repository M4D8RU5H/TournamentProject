using MediatR;
using Microsoft.EntityFrameworkCore;
using TournamentProject.Models;

namespace TournamentProject.Features.Match.Command.Create;

public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, CreateMatchCommandResult>
{
    private readonly TournamentDbContext _context;

    public CreateMatchCommandHandler(TournamentDbContext context)
    {
        _context = context;
    }

    public async Task<CreateMatchCommandResult> Handle(CreateMatchCommand command, CancellationToken cancellationToken)
    {
        var tournament = _context.Tournaments.Include(x => x.Tournament_Teams).FirstOrDefault(x => x.Id == command.TournamentId);

        if (tournament == null)
        {
            return null;
        }

        var existingMatches = _context.Matches.Any(x => x.TournamentId == tournament.Id && x.Phase-1 == tournament.Status);

        if (existingMatches)
        {
            var teamsWithWinnerIds = _context.Matches
                .Where(x => x.TournamentId == tournament.Id && x.Phase-1 == tournament.Status  && x.WinnerId != null)
                .Select(x => x.WinnerId)
                .ToList();

            var matchList = GenerateMatchesForTeams(tournament, teamsWithWinnerIds, tournament.Status);

            foreach (var match in matchList)
            {
                _context.Matches.Add(match);
            }

            await _context.SaveChangesAsync(cancellationToken);
            
        }
        else
        {
            var matchList = GenerateFirstPhaseMatches(tournament, tournament.Status);

            foreach (var match in matchList)
            {
                _context.Matches.Add(match);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
        tournament.Status -= 1;


        await _context.SaveChangesAsync(cancellationToken);

        return new CreateMatchCommandResult();
    }

    public List<Models.Match> GenerateMatchesForTeams(Models.Tournament tournament, List<int?> teamIds, int phase)
    {
        var matchesList = new List<Models.Match>();

        int teamsCount = teamIds.Count;

        for (int i = 0; i < teamsCount; i += 2)
        {
            int firstTeamIndex = i;
            int secondTeamIndex = i + 1;

            var match = new Models.Match()
            {
                Id = 0,
                FirstTeamId = (int)teamIds[firstTeamIndex],
                SecondTeamId = (int)teamIds[secondTeamIndex],
                Score = 0,
                TournamentId = tournament.Id,
                Phase = phase,
            };

            matchesList.Add(match);
        }

        return matchesList;
    }

    public List<Models.Match> GenerateFirstPhaseMatches(Models.Tournament tournament, int phase)
    {
        var matchesList = new List<Models.Match>();

        var teamIds = tournament.Tournament_Teams.Select(x => x.TeamId).ToList();

        int teamsCount = teamIds.Count;

        for (int i = 0; i < teamsCount; i += 2)
        {
            int firstTeamIndex = i;
            int secondTeamIndex = i + 1;

            var match = new Models.Match()
            {
                Id = 0,
                FirstTeamId = teamIds[firstTeamIndex],
                SecondTeamId = teamIds[secondTeamIndex],
                Score = 0,
                TournamentId = tournament.Id,
                Phase = phase,
            };

            matchesList.Add(match);
        }

        return matchesList;
    }
}