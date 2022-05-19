using Apizr;
using Apizr.Caching.Attributes;
using Apizr.Logging.Attributes;
using Apizr.Policing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Policy("TransientHttpError")]
namespace Devlin.PayPalz.Api.Sdk
{
    [WebApi("https://paypalz.dev/"), Cache, Log]
    internal interface IPayPalzApi
    {
    }
}
