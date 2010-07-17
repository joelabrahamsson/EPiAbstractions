using System;
using System.Globalization;
using EPiServer.DataAbstraction;

namespace EPiAbstractions.DataAbstraction
{
    public class LanguageBranchFacade : ILanguageBranchFacade
    {
        private static LanguageBranchFacade _instance;

        public static LanguageBranchFacade Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LanguageBranchFacade();

                return _instance;
            }

            set { _instance = value; }
        }

        #region ILanguageBranchFacade Members

        public virtual LanguageBranchCollection ListAll()
        {
            return LanguageBranch.ListAll();
        }

        public virtual LanguageBranchCollection ListEnabled()
        {
            return LanguageBranch.ListEnabled();
        }

        public virtual LanguageBranch Load(CultureInfo culture)
        {
            return LanguageBranch.Load(culture);
        }

        public virtual LanguageBranch Load(String languageCode)
        {
            return LanguageBranch.Load(languageCode);
        }

        public virtual LanguageBranch Load(Int32 id)
        {
            return LanguageBranch.Load(id);
        }

        public virtual LanguageBranch LoadFirstEnabledBranch()
        {
            return LanguageBranch.LoadFirstEnabledBranch();
        }

        public virtual void Save(LanguageBranch languageBranch)
        {
            languageBranch.Save();
        }

        public virtual void Delete(LanguageBranch languageBranch)
        {
            languageBranch.Delete();
        }

        #endregion
    }
}