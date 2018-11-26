using System;
using GiantBomb.Api;

namespace GameGallery.Models
{
    public class GiantBomb
    {

            public GiantBomb()
            {
            SetGiantBomb(new GiantBombRestClient("bbf11d4afbc46237a98e179ed5e541945d1b4bf0"));
            }

            public GiantBomb(IGiantBombRestClient giantBomb)
            {
            SetGiantBomb(giantBomb);
        }

        private IGiantBombRestClient giantBomb;

        protected IGiantBombRestClient GetGiantBomb()
        {
            return giantBomb;
        }

        private void SetGiantBomb(IGiantBombRestClient value)
        {
            giantBomb = value;
        }

        public class Api
        {
        }
    }
    }
