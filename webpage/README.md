The webpage of this project providing user interface for coach and other clerk.

## Page Logic (incomplited)

> Here describe with Chinese for readability

- 教练登入页(`coach_login`): 作为教练登入，登入后跳转至教练个人页

- 教练个人页(`coach_home`): 显示部分个人信息、当前负责的课程数、下一次课的课程安排，可跳转至教练课程表页、教练负责课程页、登出至教练登入页

- 教练课程表页(`coach_schedule`): 显示当周课程表，可登记上课，可跳转至课程详情页或教练个人页、教练负责课程页、登出至教练登入页

- 教练负责课程页(`coach_courses`): 列表，可跳转至课程详情页或教练个人页、教练课程表页、登出至教练登入页

- 教练课程详情页(`coach_course_details`): 显示课程时间，内容，参加的会员，可返回至教练负责课程页

(followings unfinished)

- 前台登入页(`reception_login`): 作为前台登入，登入后跳转至前台管理页

- 前台管理页(`reception_home`): 输入会员id（手机号）后跳转至会员课程管理页，可登出至前台登入页

- 会员课程管理页(`reception_course_manager`): 选课及退课


- 人事登入页(`manager_login`): 作为人事登入，登入后跳转至人事管理页

- 人事管理页(`manager_home`): 教练列表，可以导出教练数据，可跳转至新增教练页、教练详情页、登出至人事登入页

- 新增教练页(`manager_new_coach`): 填写教练信息，提交可注册教练账号，可返回至人事管理页

- 教练详情页(`manager_coach_details`): 显示教练个人信息，可以删除教练档案、给教练排课（增减）、修改教练个人信息，可登出至人事管理页