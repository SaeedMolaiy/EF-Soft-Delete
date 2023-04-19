namespace EF_Soft_Delete.Markers;

internal interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}