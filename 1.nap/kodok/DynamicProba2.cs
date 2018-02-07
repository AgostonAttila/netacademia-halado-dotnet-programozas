    object target = "IT Factory";
    object ar = "IT";
    Type[] argTypes = new Type[] { ar.GetType() };
    MethodInfo method = target.GetType().GetMethod("Contains", argTypes);
    object[] arguments = new object[] { ar };
    bool res = Convert.ToBoolean(method.Invoke(target, arguments));
    Console.WriteLine(res);

