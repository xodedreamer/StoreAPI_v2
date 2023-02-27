using Store.Domain.Models.Common;

namespace Store.Domain.Models
{
    public class PictureUrl : Entity
    {
        // -> Empty contructor for EF
        public PictureUrl()
        {

        }

        public PictureUrl(string url)
        {
            Url = url;
        }

        public virtual string Url { get; private set; }
    }
}
