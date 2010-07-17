using System;
using System.Globalization;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public interface ILanguageBranchFacade
    {
        LanguageBranchCollection ListAll();

        LanguageBranchCollection ListEnabled();

        LanguageBranch Load(CultureInfo culture);

        LanguageBranch Load(String languageCode);

        LanguageBranch Load(Int32 id);

        LanguageBranch LoadFirstEnabledBranch();

        void Save(LanguageBranch languageBranch);

        void Delete(LanguageBranch languageBranch);
    }
}