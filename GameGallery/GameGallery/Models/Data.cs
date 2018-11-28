using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GiantBomb.Api.Model;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace GameGallery.Models
{

        public partial class Data
        {
            [JsonProperty("error")]
            public string Error { get; set; }

            [JsonProperty("limit")]
            public long Limit { get; set; }

            [JsonProperty("offset")]
            public long Offset { get; set; }

            [JsonProperty("number_of_page_results")]
            public long NumberOfPageResults { get; set; }

            [JsonProperty("number_of_total_results")]
            public long NumberOfTotalResults { get; set; }

            [JsonProperty("status_code")]
            public long StatusCode { get; set; }

            [JsonProperty("results")]
            public Result[] Results { get; set; }

            [JsonProperty("version")]
            public string Version { get; set; }
        }

        public partial class Result
        {
            [JsonProperty("aliases")]
            public string Aliases { get; set; }

            [JsonProperty("api_detail_url")]
            public Uri ApiDetailUrl { get; set; }

            [JsonProperty("date_added")]
            public DateTimeOffset DateAdded { get; set; }

            [JsonProperty("date_last_updated")]
            public DateTimeOffset DateLastUpdated { get; set; }

            [JsonProperty("deck")]
            public string Deck { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("expected_release_day")]
            public object ExpectedReleaseDay { get; set; }

            [JsonProperty("expected_release_month")]
            public object ExpectedReleaseMonth { get; set; }

            [JsonProperty("expected_release_quarter")]
            public object ExpectedReleaseQuarter { get; set; }

            [JsonProperty("expected_release_year")]
            public object ExpectedReleaseYear { get; set; }

            [JsonProperty("guid")]
            public string Guid { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("image")]
            public Image Image { get; set; }

            [JsonProperty("image_tags")]
            public ImageTag[] ImageTags { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("number_of_user_reviews")]
            public long NumberOfUserReviews { get; set; }

            [JsonProperty("original_game_rating")]
            public OriginalGameRating[] OriginalGameRating { get; set; }

            [JsonProperty("original_release_date")]
            public DateTimeOffset? OriginalReleaseDate { get; set; }

            [JsonProperty("platforms")]
            public Platform[] Platforms { get; set; }

            [JsonProperty("site_detail_url")]
            public Uri SiteDetailUrl { get; set; }
        }

        public partial class Image
        {
            [JsonProperty("icon_url")]
            public Uri IconUrl { get; set; }

            [JsonProperty("medium_url")]
            public Uri MediumUrl { get; set; }

            [JsonProperty("screen_url")]
            public Uri ScreenUrl { get; set; }

            [JsonProperty("screen_large_url")]
            public Uri ScreenLargeUrl { get; set; }

            [JsonProperty("small_url")]
            public Uri SmallUrl { get; set; }

            [JsonProperty("super_url")]
            public Uri SuperUrl { get; set; }

            [JsonProperty("thumb_url")]
            public Uri ThumbUrl { get; set; }

            [JsonProperty("tiny_url")]
            public Uri TinyUrl { get; set; }

            [JsonProperty("original_url")]
            public Uri OriginalUrl { get; set; }

            [JsonProperty("image_tags")]
            public ImageTags ImageTags { get; set; }
        }

        public partial class ImageTag
        {
            [JsonProperty("api_detail_url")]
            public Uri ApiDetailUrl { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("total")]
            public long Total { get; set; }
        }

        public partial class OriginalGameRating
        {
            [JsonProperty("api_detail_url")]
            public Uri ApiDetailUrl { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public partial class Platform
        {
            [JsonProperty("api_detail_url")]
            public Uri ApiDetailUrl { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("site_detail_url")]
            public Uri SiteDetailUrl { get; set; }

            [JsonProperty("abbreviation")]
            public string Abbreviation { get; set; }
        }

        public enum ImageTags { AllImages, AllImagesArcFlyers, AllImagesBoxArt, AllImagesBoxArtGameCovers, AllImagesBoxArtWikiSubmissions };

        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                ImageTagsConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class ImageTagsConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ImageTags) || t == typeof(ImageTags?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "All Images":
                        return ImageTags.AllImages;
                    case "All Images,ARC Flyers":
                        return ImageTags.AllImagesArcFlyers;
                    case "All Images,Box Art":
                        return ImageTags.AllImagesBoxArt;
                    case "All Images,Box Art,Game Covers":
                        return ImageTags.AllImagesBoxArtGameCovers;
                    case "All Images,Box Art,Wiki submissions":
                        return ImageTags.AllImagesBoxArtWikiSubmissions;
                }
                throw new Exception("Cannot unmarshal type ImageTags");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ImageTags)untypedValue;
                switch (value)
                {
                    case ImageTags.AllImages:
                        serializer.Serialize(writer, "All Images");
                        return;
                    case ImageTags.AllImagesArcFlyers:
                        serializer.Serialize(writer, "All Images,ARC Flyers");
                        return;
                    case ImageTags.AllImagesBoxArt:
                        serializer.Serialize(writer, "All Images,Box Art");
                        return;
                    case ImageTags.AllImagesBoxArtGameCovers:
                        serializer.Serialize(writer, "All Images,Box Art,Game Covers");
                        return;
                    case ImageTags.AllImagesBoxArtWikiSubmissions:
                        serializer.Serialize(writer, "All Images,Box Art,Wiki submissions");
                        return;
                }
                throw new Exception("Cannot marshal type ImageTags");
            }

            public static readonly ImageTagsConverter Singleton = new ImageTagsConverter();
        }
    }