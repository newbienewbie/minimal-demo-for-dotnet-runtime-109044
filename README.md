# minimal-demo

This is a minimal demo for https://github.com/dotnet/runtime/issues/109044#issuecomment-2424178481 


- The `main` branch shows the runtime crashes when referencing the Microsoft.Extensions.Logging.Abstractions.8.0.2.nupkg
- The `works` branch shows that it runs without any problem if I use the Microsoft.Extensions.Logging.Abstractions.8.0.0.nupkg


## Steps to reproduce


- git clone this repo
- I lock my .NET SDK to `8.0.102` in `global.json`. It should be fine to roll forward to new versions, but I didn't test that.
- I use `paket` to lock the package version in `.config/dotnet-tools.json`. Run `dotnet tool restore` to make it available.


### the main branch 

- `git checkout main`
- if there's a `paket-files/` folder, remove it.
- `dotnet paket restore`   # regenerate the paket-files/

- `cd MainApp`
- `dotnet build` # it should compile 
- `dotnet run`   # it crashes



### the works branch 

- `git checkout works`
- if there's a `paket-files/` folder, remove it.
- `dotnet paket restore`   # regenerate the paket-files/

- `cd MainApp`
- `dotnet build` # it should compile 
- `dotnet run`   # it works