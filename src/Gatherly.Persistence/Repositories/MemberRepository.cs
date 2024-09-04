using Gatherly.Domain.Entities;
using Gatherly.Domain.Repositories;

namespace Gatherly.Persistence.Repositories;

internal sealed class MemberRepository : IMemberRepository
{
    private readonly DatabaseContext _dbContext;

    public MemberRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public aysnc Task<Member?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .Set<Member>()
            .First(member => member.Id == id);
    }

    public void Add(Member member)
    {
        throw new NotImplementedException();
    }
}