namespace Hapvida.Digital.Beneficiary.Admin.Domain.Resources.v1
{
    public static class LogTemplate
    {
        public const string StartHandler = "[Iniciando] handler: {handler}.";

        public const string EndHandler = "[Finalizando] handler: {handler}. | {message} ";

        public const string TraceHandler = "[Executando] -> handler: {handler}, method: {method} | {message}.";

        public const string ErrorHandler = "[Finalizando] handler: {handler}. | [Error] : {message} ";
    }
}
