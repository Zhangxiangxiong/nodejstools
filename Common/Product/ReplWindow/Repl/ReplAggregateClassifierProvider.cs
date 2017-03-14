// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Projection;
using Microsoft.VisualStudio.Utilities;

#if NTVS_FEATURE_INTERACTIVEWINDOW
namespace Microsoft.NodejsTools.Repl
{
#else
namespace Microsoft.VisualStudio.Repl {
#endif

    [Export(typeof(IClassifierProvider)), ContentType(ReplConstants.ReplContentTypeName)]
    internal class ReplAggregateClassifierProvider : IClassifierProvider
    {
        [Import]
        private IBufferGraphFactoryService _bufferGraphFact = null; // set via MEF

        #region IClassifierProvider Members

        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            ReplAggregateClassifier res;
            if (!textBuffer.Properties.TryGetProperty<ReplAggregateClassifier>(typeof(ReplAggregateClassifier), out res))
            {
                res = new ReplAggregateClassifier(_bufferGraphFact, textBuffer);
                textBuffer.Properties.AddProperty(typeof(ReplAggregateClassifier), res);
            }
            return res;
        }

        #endregion
    }
}

