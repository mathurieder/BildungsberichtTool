using System;

namespace BildungsberichtTemplate
{
    public class GenderTranslate
    {
        private String key;
        private String maleText;
        private String femaleText;

        public GenderTranslate(String key, String maleText, String femaleText)
        {
            this.key = key;
            this.maleText = maleText;
            this.femaleText = femaleText;
        }

        public String getKey()
        {
            return this.key;
        }

        public String getMaleText()
        {
            return this.maleText;
        }

        public String getFemaleText()
        {
            return this.femaleText;
        }
    }
}
