using System.ComponentModel;

namespace PruebaTecnica.Domain.Enums;
public enum EventType
{
    [Description("Api")]
    Api = 0,

    [Description("Formulario de eventos manuales")]
    FormularioDeEventosManuales = 1
}
