﻿using Persistity.Core.Serialization;
using Persistity.Encryption;
using Persistity.Flow.Builders;
using Strem.Infrastructure.Services.Persistence.Generic;

namespace Strem.Infrastructure.Services.Persistence.App;

public class SaveAppVariablesPipeline : SaveVariablesPipeline, ISaveAppVariablesPipeline
{
    public override string VariableFilePath => $"{PathHelper.AppDirectory}app.dat";
    public override bool IsEncrypted => false;
    
    public SaveAppVariablesPipeline(PipelineBuilder pipelineBuilder, ISerializer serializer, IEncryptor encryptor) : base(pipelineBuilder, serializer, encryptor)
    {
    }
}