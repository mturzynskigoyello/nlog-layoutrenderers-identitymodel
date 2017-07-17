using System.Linq;
using System.Security.Claims;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.IdentityModel
{
    [LayoutRenderer("claim-value")]
    public class ClaimValueLayoutRenderer : LayoutRenderer
    {
        [RequiredParameter]
        [DefaultParameter]
        public string TypeName { get; set; }

        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var claimValue = ClaimsPrincipal.Current?.Claims.FirstOrDefault(x => x.Type == TypeName)?.Value ?? string.Empty;
            builder.Append(claimValue);
        }
    }
}
