﻿namespace MiniBankApp.Communication.Responses.Shared
{
    public class ResponseErrorJson
    {
        public List<string> ErrorMessages { get; set; }

        public ResponseErrorJson(string errorMessage)
        {
            ErrorMessages = [errorMessage];
        }

        public ResponseErrorJson(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}