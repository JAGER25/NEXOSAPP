using MediatR;
using Microsoft.EntityFrameworkCore;
using NEXOSAPI.Domain.Entities;
using NEXOSAPI.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.CustomerFeatures.Queries
{
    public class GetAllAuthorQuery : IRequest<IEnumerable<Book>>
    {

        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Book>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCustomerQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Book>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
            {
                var bookList = await _context.Books.ToListAsync();
                if (bookList == null)
                {
                    return null;
                }
                return bookList.AsReadOnly();
            }
        }
    }
}
