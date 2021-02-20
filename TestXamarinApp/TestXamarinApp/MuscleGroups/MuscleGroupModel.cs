using System;
using System.Collections.Generic;
using System.Text;

namespace TestXamarinApp.MuscleGroups
{
    class MuscleGroupModel
    {
        private int _idGroup;
        private string _groupName;
        private string _groupPicture;
        public int IdGroup { get { return _idGroup; } set { _idGroup = value; } }
        public string GroupName { get { return _groupName; } set { _groupName = value; } }
        public string GroupPicture { get { return _groupPicture; } set { _groupPicture = value; } }
        public MuscleGroupModel(int id, string name, string picture)
        {
            _idGroup = id;
            _groupName = name;
            _groupPicture = picture;
        }
    }
}
