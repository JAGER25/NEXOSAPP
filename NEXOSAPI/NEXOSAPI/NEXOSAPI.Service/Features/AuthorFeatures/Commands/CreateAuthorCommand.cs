using MediatR;
using NEXOSAPI.Domain.Entities;
using NEXOSAPI.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Features.AuthorFeatures.Commands
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public string CityOrigin { get; set; }

        public int IdMaximumBooks { get; set; }
        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateAuthorCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                var author = new Author();
                author.CityOrigin = request.CityOrigin;
                author.DateBirth = request.DateBirth;
                author.FullName = request.FullName;
                author.MaximumBooks = _context.MaximumBooks.Find(request.IdMaximumBooks);

                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return author.Id;
            }
        }
    }
}
