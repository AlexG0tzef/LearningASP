using fASP.Domain.Entities;
using fASP.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace fASP.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldRepository
    {
        private readonly AppDbContext context;

        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TextField> GetTextFields() 
        {
            return context.textFields; 
        }

        public TextField GetTextFieldById(int ID)
        {
            return context.textFields.Where(x => x.Id == ID).FirstOrDefault();
        }

        public TextField GetTextFieldByCodeWord(string codeWord) 
        {
            return context.textFields.Where(x => x.CodeWord == codeWord).FirstOrDefault();
        }

        public void SaveTextField(TextField entity) 
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeleteTextField(int ID)
        {
            context.textFields.Remove(new TextField() { Id = ID });
            context.SaveChanges();
        }
    }
}
