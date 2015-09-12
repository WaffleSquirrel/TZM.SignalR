using System;
using System.Reflection;

namespace ZM.SignalR.Integrations.WebApiMvc.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}