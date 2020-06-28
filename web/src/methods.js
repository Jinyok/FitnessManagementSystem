var axios = require ('axios');

var url = 'https://localhost:5001/api/'

var methods = {
    login: (account, passwd,) => {
    },
    getCoachesById: (coachId, callback) => {
        axios.get(url+'Coaches/GetCoachesById', { params: { id: coachId } })
        .then(function (response) {
            callback(response.data.data)
        })

    },
    getCoaches: (callback) => {
        axios.get(url+'Coach/GetCoaches')
        .then(function(response) {
            callback(response.data.data)
        })
    },
    deleteCoach: (id) => {
    },
    updateCoach: (coachId, name, phone, email, callback) => {
        axios.put(url+'Coaches/UpdateCoacah', {
            CoachId: coachid, Name: name, PhoneNo: phone,
            Email: email, State: 'InOffice'
        })
        .then(function(response) {
            callback(response.data.data)
        })
    },
    getCourses: (callback) => {
        axios.get(url+'Courses/GetCourses')
        .then(function(response) {
            callback(response.data.data)
        })
    },
    getCourseById: (courseId, callback) => {
        axios.get(url+'Courses/GetCoursesById', { params:{ id: courseId }})
        .then(function(response) {
            callback(response.data.data)
        })
    },
    updateCourse: (courseId, title, cost, classHour, callback) => {
        axios.put(url+'Courses/UpdateCourse', {
            CourseId: courseId, Title: title, Cost: cost, ClassHour: classHour
        })
        .then(function(response) {
            callback(response.data.data)
        })
    },
    deleteCourse: (courseId, callback) => {
        axios.delete(url+'Courses/DeleteCourse', { CourseId: courseId })
        .then(function(response) {
            callback(response.data.data)
        })
    }, 
    updateCourse: () => {
    },
    getCoachCourses: (coachId) => {
    },
    getCoachSections: (coachId) => {
    },
    addSection: (coachId, courseId, callback) => {
        axios.post(url+'Sections/AddSection', { CoachId: coachId, CourseId: courseId })
        .then(function(response) {
            callback(response.data.data)
        });
    },
    addLesson(sectionId, coachId, startDate, endDate, callback) {
        axios.post(url+'Sections/AddLesson', {
            SectionId: sectionId, CoachId: coachId,
            StartDate: startDate, EndDate: endDate
        })
        .then(function(response) {
            callback(response.data.data)
        });
    },
    GetFirstLessonByCoachId: (coachId, callback) => {
        axios.get(url+'Sections/GetFirstLessonByCoachId', { params: { CoachId : coachId } })
        .then (function (response) {
            //console.log(response.data.data)
            if (response.data.data == null)
                callback (undefined)
            else    callback(response.data.data)
        } )
    },
    GetCoachLessons: (CoachId, StartDate, Number, callback) => {
        axios.get(url+'Sections/GetCoachLesson', { params: 
            { coachid : CoachId, startdate : StartDate, num: Number } })
        .then (function (response) {
            //console.log(response.data.data)
            callback(response.data.data)
        } )
    },
    GetSectionByCoachId: (coachId, callback) => {
        axios.get(url+'Sections/GetSectionByCoachId', { params: { Coachid : coachId } })
        .then (function (response) {
            //console.log(response)
            callback(response.data.data)
        } )
    },
    GetSectionBySectionId: (sectionId, callback) => {
        axios.get(url+'Sections/GetSectionBySectionId', { params: { SectionId : sectionId } })
        .then (function (response) {
            callback(response.data.data)
        } )
    },
    GetSectionMembers: async (sectionId, callback) => {
        let a = await axios.get(url+'Sections/GetSectionMembers', { params: { SectionId : sectionId } });

        callback(a.data.data)
        //a.then( function (response) { return response; } )
        /*axios.get(url+'Sections/GetSectionMembers', { params: { SectionId : sectionId } })
        .then (function (response) {
            callback(response.data.data)
        } )*/
    },
    GetInstructsByCoachId: (coachId, callback) => {
        axios.get(url+'Courses/GetPersonalCoursesByCoachId', { params: { CoachId : coachId } })
        .then (function (response) {
            callback(response.data.data)
        } )
    },
    UpdateInstruct: (instruct, callback) => {
        axios.put(url+'Courses/UpdatePersonalCourse', {
            memberId: instruct.memberId,
            coachId: instruct.coachId,
            attendedHours: instruct.attendedHours,
            totalHours: instruct.totalHours
        })
        .then (function (response) {
            callback(response)
        } )
    },
    GetAllUsers: (callback) => {
        axios.get(url+'Users/GetUser')
        .then (function (response) {
            callback(response.data.data)
        } )
    },
    GetUserInfo: (User, callback) => {
        switch (User.role) {
            case 'Admin': callback(undefined); break;
            case 'Coach': 
                axios.get(url+'Coaches/GetCoachesById', { params: { id: User.number } } )
                .then (function (response) {
                    callback(response.data.data)
                } )
                break;
            case 'Clerk': callback(undefined); break;
            case 'Member': 
                axios.get(url+'Members/GetMembersById', { params: { id: User.number } } )
                .then (function (response) {
                    callback(response.data.data)
                } )
                break;
        }
    },
    SubmitUserInfo: (UserInfo, ExtraInfo, callback) => {
        axios.put(url + 'Users/PutUser', { 
            userId: UserInfo.userId,
            userName: UserInfo.userName,
            password: UserInfo.password,
            role: UserInfo.role,
            number: UserInfo.number,
            createTime: UserInfo.createTime
            })
        .then (function () {
            switch (UserInfo.role) {
                case 'Coach':
                    axios.put(url + 'Coaches/UpdateCoach', {
                        coachId: ExtraInfo.coachId,
                        name: ExtraInfo.name,
                        phoneNo: ExtraInfo.phoneNo,
                        email: ExtraInfo.email,
                        state: ExtraInfo.state
                    })
                    .then (callback())
                    break;
            }
        } )
    },
    AddUser: (UserInfo, ExtraInfo, callback) => {
        switch(UserInfo.role) {
            case 'Coach':
            axios.post(url + 'Coaches/AddCoach', {
                name: ExtraInfo.name,
                phoneNo: ExtraInfo.phoneNo,
                email: ExtraInfo.email,
                })
            .then (function (response) {
                console.log(response)
                axios.post(url + 'Users/PostUser', {
                    userName: UserInfo.userName,
                    password: UserInfo.password,
                    number: response.data.data.coachId,
                    role: "Coach"
                })
                .then (callback())
            } )
            break;

            case 'Member':
            axios.post(url + 'Members/AddMember', {
                name: ExtraInfo.name,
                phoneNo: ExtraInfo.phoneNo
                })
            .then (function (response) {
                axios.post(url + 'Users/PostUser', {
                    userName: UserInfo.userName,
                    password: UserInfo.password,
                    number: response.data.data.memberId,
                    role: "Member"
                })
                .then (callback())
            } )
            break;

            default:
            axios.post(url + 'Users/PostUser', {
                userName: UserInfo.userName,
                password: UserInfo.password,
                role: UserInfo.role
            })
            .then (callback())
            break;
        }
    }
};

export default methods;