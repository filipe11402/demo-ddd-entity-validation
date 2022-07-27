### What is Always valid Domain Model?
DDD states, that whenever creating a entity, that same one, should always be in a valid state and not on an invalid one.
Of course, this is a rule that was estipulated and should be followed, but we shouldn't use this as a Rule on which our lives depend on, sometimes rules are meant to be broken.

### Context of this project
This project consists of an example of registering a new user, but of course, that contains some validations such as some data cannot be null. **These validations are not business rules**.

So, starting out, what we needed was, to now allow someone when creating a ``new User``, so for that we should just create a private ctor, because the User entity should be the one calling himself.
Also, by applying one of the core principles of the OOP, we also use the correct access modifiers in the User entity.

Now, to force always the creation of that same entity, it was created a method called ``Factory()`` that will receive the parameters needed for creation and perform the validations. In the end, we return a ``tuple()``, that will return validations errors or the entity that was created successfully.

### Final thoughts
By applying this logic, we can achieve 2 very important things that aggree on the principle that this demo project lays one
- Force validation when creating the entity
- Not allowing the entity entering in an invalid state

### References
[Code Opinion](https://www.youtube.com/watch?v=JZetlRXdYeI)
[Enterprise craftsmanship](https://enterprisecraftsmanship.com/posts/always-valid-domain-model/)