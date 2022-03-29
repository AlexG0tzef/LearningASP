using fASP.Domain.Entities;

namespace fASP.Domain.Repositories.Abstract
{
    public interface ITextFieldRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid ID);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextField(TextField entity);
        void DeleteTextField(Guid ID);
    }
}
