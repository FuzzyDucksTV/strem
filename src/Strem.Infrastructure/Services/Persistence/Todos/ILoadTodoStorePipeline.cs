using Strem.Core.Flows;
using Strem.Infrastructure.Services.Persistence.Generic;

namespace Strem.Infrastructure.Services.Persistence.Todos;

public interface ILoadTodoStorePipeline : ILoadDataPipeline<TodoStore>
{
}