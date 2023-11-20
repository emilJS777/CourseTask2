hi I built a backend application based on your assignment.
When examining the assignment, I got confused about editing the user and courses, I didn’t really understand: should the user edit other users or should he edit himself?!
I also didn’t quite understand how the logic of courses (many to many) or (one to many) should work, that is, one user and many courses or many users and many courses,
I also did not understand this point. but in the end I created a logic (many to many)
but I built the project according to my understanding, if there is something to fix for re-inspection, you can write to me and I will fix it.
------
Let's start. I will try to describe as clearly as possible what I created and how it works
------
after the database migration, a user is automatically created, a profile and 2 courses, this is the seed date as it was in the task.
by default (username: seeduser | password: seedpassword) for user login

without a login you cannot edit or receive courses, you also cannot receive users,
without a login you can only register and log in
-----
When testing we take the following steps

register and log in - copy the JWT and paste it into Authorize, now we can assume that we are logged in
Now we can create, get delete and edit courses

if you need to link any courses to a user, go to /CourseUser (POST) and in the list we pass the identifiers of those courses that you want to link to the user,
example “courseIds”: [1, 2, 3]. In this way we have attached to the user, now when geting a user, his courses are displayed there.
if you want to unlink a user from courses, then we go to /CourseUser (DELETE) and pass the course identifiers, example “courseIds”: [1, 2] and these courses will be unlinked.

This is the main part of the project logic, there are other functions such as deleting and updating courses and user.
I’m not describing them here, I think everything will be clear there



