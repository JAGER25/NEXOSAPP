using MediatR;
using Microsoft.EntityFrameworkCore;
using NEXOSAPI.Domain.Entities;
using NEXOSAPI.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.AuthorFeatures.Queries
{
    public class GetAllAuthorQuery : IRequest<IEnumerable<Author>>
    {

        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Author>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllCustomerQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
            {
                var authorList = await _context.Authors.ToListAsync();
                if (authorList == null)
                {
                    return null;
                }
                return authorList.AsReadOnly();
            }
        }
    }
}
