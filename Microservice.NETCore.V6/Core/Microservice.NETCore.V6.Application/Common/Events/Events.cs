namespace Microservice.NETCore.V6.Application.Common.Events
{
    public enum Information
    {
        GetDispatchesInformation = 0,
        GetDispatchesControllerInformation,
        GetDispatchesByIdInformation,
        GetDispatchesByIdControllerInformation,
    }

    public enum Warning
    {
        GetDispatchesWarning = 1000,
        GetDispatchesByIdWarning
    }
}