// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using Microsoft.VisualStudioTools;

namespace Microsoft.NodejsTools.Commands
{
    internal sealed class SurveyNewsCommand : Command
    {
        public override void DoCommand(object sender, EventArgs args)
        {
            NodejsPackage.Instance.CheckSurveyNews(true);
        }

        public override int CommandId => (int)PkgCmdId.cmdidSurveyNews;
    }
}

