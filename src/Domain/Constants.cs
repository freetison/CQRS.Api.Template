namespace $safeprojectname$
{
    public static class Constants
    {
        public enum ApiExceptionEnum
        {
            NotFoundException = -401,
            DomainValidationException = -407,
            AccessValidationException = -409,
            DetailedValidationException = -410,
            ApiException = -411,
            InternalServerErrorException = -500
        }
    }
}
