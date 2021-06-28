using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Todos
{
  public class List
  {
    public class Query : IRequest<List<Todo>>
    {

    }

    public class Handler : IRequestHandler<Query, List<Todo>>
    {
      private readonly DataContext _context;
      private readonly ILogger<List> _logger;
      public Handler(DataContext context)
      {
       
        _context = context;

      }
      public async Task<List<Todo>> Handle(Query request, CancellationToken cancellationToken)
      {
       

        return await _context.Todos.ToListAsync(cancellationToken);
      }
    }
  }
}