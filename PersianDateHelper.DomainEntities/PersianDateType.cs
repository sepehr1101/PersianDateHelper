namespace PersianDateHelper.DomainEntities
{
    public enum PersianDateType
    {
        SixChar,//  yyMMdd
        EightCharWithoutSlash,//  yyyyMMdd
        EightCharWithSlash,//  yy/mm/dd
        TenChar//  yyyy/mm/dd
    }
}