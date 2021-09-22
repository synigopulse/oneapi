using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Synigo.OneApi.Common.Extensions;

namespace Synigo.OneApi.Test.Mock
{
    public class MockHttpRequest : HttpRequest
    {
        private readonly Dictionary<string, string> _headers;
        private readonly object _data;

        public MockHttpRequest()
        {

        }

        public MockHttpRequest(Dictionary<string, string> headers)
        {
            _headers = headers;
        }

        public MockHttpRequest(Dictionary<string, string> headers, object data)
        {
            _headers = headers;
            _data = data;
        }

        public override HttpContext HttpContext => throw new NotImplementedException();

        public override string Method { get; set; }
        public override string Scheme { get { return "https"; } set { } }
        public override bool IsHttps { get { return true; } set { } }
        public override HostString Host { get { return new HostString("localhost", 443); } set { } }
        public override PathString PathBase { get { return new PathString("/"); } set { } }
        public override PathString Path { get { return new PathString("/"); } set { } }
        public override QueryString QueryString { get; set; }
        public override IQueryCollection Query { get; set; }
        public override string Protocol { get { return "http"; } set { } }

        public override IHeaderDictionary Headers
        {
            get
            {
                var headers = new HeaderDictionary();
                foreach (var header in _headers)
                {
                    headers.Add(header.Key, new StringValues(header.Value));
                }

                return headers;
            }
        }

        public override IRequestCookieCollection Cookies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override long? ContentLength
        {
            get
            {
                if (_data == null)
                {
                    return 0;
                }

                var value = _data.Serialize();
                return Encoding.UTF8.GetByteCount(value);
            }
            set
            {
            }
        }
        public override string ContentType { get => "application/json"; set => throw new NotImplementedException(); }
        public override Stream Body { get {
                if (_data == null)
                {
                    return null;
                }

                using var memStream = new MemoryStream();
                var val = _data.Serialize();
                using var writer = new StreamWriter(memStream);
                writer.Write(val);
                writer.Flush();
                memStream.Seek(0, SeekOrigin.Begin);
                return memStream;
            }
            set { }
        }

        public override bool HasFormContentType => false;

        public override IFormCollection Form { get => null; set { } }

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(default(IFormCollection));
        }
    }
}