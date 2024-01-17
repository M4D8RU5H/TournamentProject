﻿namespace TournamentProject.Features.Message.Queries.GetSingle
{
    public class GetSingleMessageQueryResult
    {
        public MessageDto Message { get; set; }
        public class MessageDto
        {
            public int Id { get; set; }
            public int SenderId { get; set; }
            public int ReceiverId { get; set; }
            public string Content { get; set; }
            public bool Readed { get; set; }


        }
    }
}
