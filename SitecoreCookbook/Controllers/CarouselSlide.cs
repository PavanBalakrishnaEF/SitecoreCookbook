using Sitecore.Data.Items;
using SitecoreCookbook.Models;

namespace SitecoreCookbook.Controllers
{
    internal class CarouselSlide : CarouselItem
    {
        public CarouselSlide(Item innerItem) : base(innerItem)
        {
        }
    }
}