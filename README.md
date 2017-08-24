# ThreadExceptionLab

## Mamy tu test obsługi wyjątków w  3 przypadkach:

### - Wyjątek wątku nie przechwycony

```c#
private void NotHandleExcetpion()
        {
            Thread thread = new Thread(() =>
            {
                throw new Exception("Nie przechwycony wjątęk");
            }
           );

            thread.Start();
        }
```

### - Wyjątek wątku zalogowany, ale nie przechwycony dobrze już tego nie pamiętam.


```c#
private void HandleExceptionByAppDomain()
        {
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Thread thread = new Thread(() =>
            {
                throw new Exception("Ten wyjatek powinno przechwycić prze AppDomain.");
            }
            );
            thread.Start();
        }
```

### - Wyjątek wątku przechwycony i obsłużony

```c#
private void HandleException()
        {
            Thread thread = new Thread(() =>
                {
                    try
                    {
                        throw new Exception("Wyjątek obsłużony.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Wyjątek przechwycony.");
                        Console.WriteLine(e.Message);
                    }
                }
            );

            thread.Start();
        }
```

