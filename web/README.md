The webpage of this project providing user interface for coach and other clerk.

## Usage

1. Install dependencies

  ```
  npm install
  ```

2. Develop mode

  ```
  npm run devserver
  ```

3. Build pages

  ```
  npm run build
  ```

4. Start server

  ```
  npm run server
  ```

## Page Logic (incomplete)

> Here describe with Chinese for readability

### 教练 (coach)

- 教练登入页(`coach_login`): 作为教练登入，登入后跳转至教练个人页（下列所有页面可以直接登出至该页面）

- 教练个人页(`coach_home`): 显示部分个人信息、当前负责的课程数、下一次课的课程安排，可跳转至教练课程表页、教练负责课程页

- 教练课程表页(`coach_schedule`): 显示当周课程表，可登记上课，可跳转至课程详情页或教练个人页、教练负责课程页

- 教练负责课程页(`coach_courses`): 列表，可跳转至课程详情页或教练个人页、教练课程表页

- 教练课程详情页(`coach_course_details`): 显示课程时间，内容，参加的会员，可返回至教练负责课程页

### 人事 (manager)

- 人事登入页(`manager_login`): 作为人事登入，登入后跳转至教练管理页（下列所有页面可以直接登出至该页面）

- 人事教练管理页(`manager_coaches`): 教练列表，可以导出教练数据，可通过筛选显示符合条件的教练，可通过搜索教练id跳转至特定人事教练详情页，可跳转至人事新增教练页、人事教练详情页

- 人事新增教练页(`manager_new_coach`): 填写教练信息，提交可注册教练账号，可返回至人事教练管理页

- 人事教练详情页(`manager_coach_details`): 显示教练个人信息与教练课程列表，可以删除教练档案、给教练排课（增减）、修改教练个人信息
  > 此处的排课通过弹窗进行，输入课程id及选择时间，时间冲突报错

- 人事课程管理页(`manager_courses`): 课程列表，可以导出课程数据，可通过筛选显示符合条件的课程，可通过搜索课程id跳转至指定人事课程详情页，可跳转至人事新增课程页、人事课程详情页

- 人事新增课程页(`manager_new_course`): 填写课程信息，提交可新增课程，可返回至人事课程管理页

- 人事课程详情页(`manager_course_details`): 显示课程详情、负责教练、参与成员，可修改课程信息、删除课程，可返回至人事课程管理页

### 前台 (reception)

- 前台登入页(`reception_login`): 作为前台登入，登入后跳转至前台管理页（下列所有页面可以直接登出至该页面）

> 下列所有页面侧栏均有一输入框，可通过输入会员id来显示特定会员的信息

- 前台课程管理页(`reception_course_manager`): 显示会员已选课程列表，可退课，可跳转至前台选课列表页

- 前台选课列表页(`reception_courses`): 显示课程列表，可通过筛选显示符合条件的课程，可选课，可跳转至前台课程管理页

(followings unfinished)

### 系统管理员 (admin)