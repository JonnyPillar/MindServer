﻿using MindServer.Domain.DataContracts.AbstractDataContracts;

namespace MindServer.Domain.DataContracts
{
    public class AccountLogInResponse : BaseResponseContract
    {
        public string SessionToken { get; set; }
    }
}