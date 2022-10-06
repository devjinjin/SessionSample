# .net core session 샘플

설정값 10초 Swagger로 테스트

  Program.cs 내

```
...
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { 
    options.IdleTimeout = TimeSpan.FromSeconds(10);
});
...
app.UseSession();
...

```
  테스트 SessionController 사용
