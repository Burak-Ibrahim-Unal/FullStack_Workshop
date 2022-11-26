namespace Core.Utilities
{
    public static class Messages
    {
        //Photo Messages
        public static string PhotoAdded = "Photo has been added successfully";
        public static string PhotoDeleted = "Photo has been deleted successfully";
        public static string PhotoUpdated = "Photo has been updated successfully";

        public static string PhotoNotAdded = "Problem occured while adding Photo";
        public static string PhotoNotDelete = "Problem occured while deleting Photo from Cloudinary";
        public static string PhotoNotUpdated = "Problem occured while updating Photo";

        public static string PhotoNotDeleteFromApi = "Problem occured while deleting Photo from Api";
        public static string PhotoMainNotDelete = "You cant delete your main photo";



        // Login - Register
        public static string EmainInUse = "Photo has been added successfully";



        // Activity
        public static string ActivityUpdateFailed = "Failed to update activity...";
        public static string FailedCreateActivity = "Failed to create activity...";
        public static string FailedDeleteActivity = "Failed to delete activity...";


        // Attendee
        public static string AttendanceUpdateFailed = "Problem occured while updating attendance...";


        // Comments
        public static string FailedAddComment = "Failed to add comment...";
        public static string CommentUpdateFailed = "Failed to update comment...";
        public static string FailedDeleteComment = "Failed to delete comment...";
        public static string ReceivedMessage = "Comment is received";
        public static string CommentsLoaded = "Comments are loaded";
    }
}