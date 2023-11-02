using Azure;
using FB.Data;
using FB.Models.Domain;
using FB.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FB.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly FB_DBContext fB_DBContext;
        public TagRepository(FB_DBContext fB_DBContext)
        {
            this.fB_DBContext = fB_DBContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await fB_DBContext.Tags.AddAsync(tag);
            await fB_DBContext.SaveChangesAsync();

            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await fB_DBContext.Tags.FindAsync(id);

            if (existingTag != null)
            { 
                fB_DBContext.Tags.Remove(existingTag);
                await fB_DBContext.SaveChangesAsync(); 
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
           return await fB_DBContext.Tags.ToListAsync();

             
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            var tag = await fB_DBContext.Tags.FindAsync(id);
            if (tag != null)
            {
                
                return tag;
            }

            return null;
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await fB_DBContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Id = tag.Id;
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await fB_DBContext.SaveChangesAsync();

                return existingTag;
            }
            return null;
        }
    }
}
