using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFxLib
{
    public class SomeService
    {
        private readonly ILogger<SomeService> _logger;

        public SomeService(ILogger<SomeService> logger)
        {
            this._logger = logger;
        }

        public void DoSth()
        {
            this._logger.LogInformation("Handler invokes From the .NetFx");
        }
    }
}
