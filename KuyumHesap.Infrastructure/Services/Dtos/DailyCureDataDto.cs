using System.Text.Json.Serialization;

namespace KuyumHesap.Infrastructure.Services.Dtos
{
    public class DailyCureDataDto
    {
        public class ALTIN
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class ATA5ESKI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class ATA5YENI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class ATAESKI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class ATAYENI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class AUDTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class AUDUSD
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class AYAR14
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class AYAR22
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class CADTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class CEYREKESKI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class CEYREKYENI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class CHFTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class Data
        {
            [JsonPropertyName("USDTRY")]
            public USDTRY USDTRY { get; set; }

            [JsonPropertyName("ALTIN")]
            public ALTIN ALTIN { get; set; }

            [JsonPropertyName("USDPURE")]
            public USDPURE USDPURE { get; set; }

            [JsonPropertyName("EURTRY")]
            public EURTRY EURTRY { get; set; }

            [JsonPropertyName("ONS")]
            public ONS ONS { get; set; }

            [JsonPropertyName("EURUSD")]
            public EURUSD EURUSD { get; set; }

            [JsonPropertyName("USDKG")]
            public USDKG USDKG { get; set; }

            [JsonPropertyName("EURKG")]
            public EURKG EURKG { get; set; }

            [JsonPropertyName("GBPTRY")]
            public GBPTRY GBPTRY { get; set; }

            [JsonPropertyName("AYAR22")]
            public AYAR22 AYAR22 { get; set; }

            [JsonPropertyName("CHFTRY")]
            public CHFTRY CHFTRY { get; set; }

            [JsonPropertyName("AUDTRY")]
            public AUDTRY AUDTRY { get; set; }

            [JsonPropertyName("KULCEALTIN")]
            public KULCEALTIN KULCEALTIN { get; set; }

            [JsonPropertyName("CADTRY")]
            public CADTRY CADTRY { get; set; }

            [JsonPropertyName("XAUXAG")]
            public XAUXAG XAUXAG { get; set; }

            [JsonPropertyName("CEYREK_YENI")]
            public CEYREKYENI CEYREK_YENI { get; set; }

            [JsonPropertyName("SARTRY")]
            public SARTRY SARTRY { get; set; }

            [JsonPropertyName("CEYREK_ESKI")]
            public CEYREKESKI CEYREK_ESKI { get; set; }

            [JsonPropertyName("USDCHF")]
            public USDCHF USDCHF { get; set; }

            [JsonPropertyName("YARIM_YENI")]
            public YARIMYENI YARIM_YENI { get; set; }

            [JsonPropertyName("JPYTRY")]
            public JPYTRY JPYTRY { get; set; }

            [JsonPropertyName("YARIM_ESKI")]
            public YARIMESKI YARIM_ESKI { get; set; }

            [JsonPropertyName("AUDUSD")]
            public AUDUSD AUDUSD { get; set; }

            [JsonPropertyName("TEK_YENI")]
            public TEKYENI TEK_YENI { get; set; }

            [JsonPropertyName("SEKTRY")]
            public SEKTRY SEKTRY { get; set; }

            [JsonPropertyName("TEK_ESKI")]
            public TEKESKI TEK_ESKI { get; set; }

            [JsonPropertyName("DKKTRY")]
            public DKKTRY DKKTRY { get; set; }

            [JsonPropertyName("USDCAD")]
            public USDCAD USDCAD { get; set; }

            [JsonPropertyName("ATA_YENI")]
            public ATAYENI ATA_YENI { get; set; }

            [JsonPropertyName("NOKTRY")]
            public NOKTRY NOKTRY { get; set; }

            [JsonPropertyName("ATA_ESKI")]
            public ATAESKI ATA_ESKI { get; set; }

            [JsonPropertyName("USDSAR")]
            public USDSAR USDSAR { get; set; }

            [JsonPropertyName("ATA5_YENI")]
            public ATA5YENI ATA5_YENI { get; set; }

            [JsonPropertyName("USDJPY")]
            public USDJPY USDJPY { get; set; }

            [JsonPropertyName("ATA5_ESKI")]
            public ATA5ESKI ATA5_ESKI { get; set; }

            [JsonPropertyName("GBPUSD")]
            public GBPUSD GBPUSD { get; set; }

            [JsonPropertyName("GREMESE_YENI")]
            public GREMESEYENI GREMESE_YENI { get; set; }

            [JsonPropertyName("GREMESE_ESKI")]
            public GREMESEESKI GREMESE_ESKI { get; set; }

            [JsonPropertyName("AYAR14")]
            public AYAR14 AYAR14 { get; set; }

            [JsonPropertyName("GUMUSTRY")]
            public GUMUSTRY GUMUSTRY { get; set; }

            [JsonPropertyName("XAGUSD")]
            public XAGUSD XAGUSD { get; set; }

            [JsonPropertyName("GUMUSUSD")]
            public GUMUSUSD GUMUSUSD { get; set; }

            [JsonPropertyName("XPTUSD")]
            public XPTUSD XPTUSD { get; set; }

            [JsonPropertyName("XPDUSD")]
            public XPDUSD XPDUSD { get; set; }

            [JsonPropertyName("PLATIN")]
            public PLATIN PLATIN { get; set; }

            [JsonPropertyName("PALADYUM")]
            public PALADYUM PALADYUM { get; set; }
        }

        public class Dir
        {
            [JsonPropertyName("alis_dir")]
            public string alis_dir { get; set; }

            [JsonPropertyName("satis_dir")]
            public string satis_dir { get; set; }
        }

        public class DKKTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class EURKG
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class EURTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class EURUSD
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class GBPTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class GBPUSD
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class GREMESEESKI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class GREMESEYENI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class GUMUSTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class GUMUSUSD
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class JPYTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class KULCEALTIN
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class Meta
        {
            [JsonPropertyName("time")]
            public long time { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }
        }

        public class NOKTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class ONS
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class PALADYUM
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class PLATIN
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("meta")]
            public Meta meta { get; set; }

            [JsonPropertyName("data")]
            public Data data { get; set; }
            public string Message { get; set; }=string.Empty;
        }

        public class SARTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class SEKTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class TEKESKI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class TEKYENI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class USDCAD
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class USDCHF
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class USDJPY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class USDKG
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class USDPURE
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class USDSAR
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class USDTRY
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public string alis { get; set; }

            [JsonPropertyName("satis")]
            public string satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class XAGUSD
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class XAUXAG
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public double alis { get; set; }

            [JsonPropertyName("satis")]
            public double satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public double dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public double yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public double kapanis { get; set; }
        }

        public class XPDUSD
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class XPTUSD
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class YARIMESKI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }

        public class YARIMYENI
        {
            [JsonPropertyName("code")]
            public string code { get; set; }

            [JsonPropertyName("alis")]
            public int alis { get; set; }

            [JsonPropertyName("satis")]
            public int satis { get; set; }

            [JsonPropertyName("tarih")]
            public string tarih { get; set; }

            [JsonPropertyName("dir")]
            public Dir dir { get; set; }

            [JsonPropertyName("dusuk")]
            public int dusuk { get; set; }

            [JsonPropertyName("yuksek")]
            public int yuksek { get; set; }

            [JsonPropertyName("kapanis")]
            public int kapanis { get; set; }
        }


    }
}
