using System.Collections.Generic;

namespace AkademiPlusSignalRapi.Dal
{
    public class Room
    {
        public int RoomID { get; set; }
        public int RoomName { get; set; }
        public List<User> Users { get; set; }
    }
}
