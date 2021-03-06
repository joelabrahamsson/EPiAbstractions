solution_file = "EPiAbstractions.sln"
configuration = "release"

target default, (init, compile, deploy, package):
  pass

target init:
  rmdir("build")
  
desc "Compiles the solution"
target compile:
  msbuild(file: solution_file, configuration: configuration)
  
desc "Copies the binaries to the 'build' directory"
target deploy:
  print "Copying to build dir"

  with FileList("EPiAbstractions/bin/${configuration}/"):
    .Include("*.{dll,xml}")
    .ForEach def(file):
      file.CopyToDirectory("build/${configuration}")
	  
  with FileList("EPiAbstractions.Fakes/bin/${configuration}/"):
    .Include("*.{dll,xml}")
    .ForEach def(file):
      file.CopyToDirectory("build/${configuration}")
	  
  with FileList("EPiAbstractions.Opinionated/bin/${configuration}/"):
    .Include("*.{dll,xml}")
    .ForEach def(file):
      file.CopyToDirectory("build/${configuration}")
	  
  with FileList("EPiAbstractions.FixtureSupport/bin/${configuration}/"):
    .Include("*.{dll,xml}")
    .ForEach def(file):
      file.CopyToDirectory("build/${configuration}")

desc "Creates zip package"
target package:
  zip("build/${configuration}", 'build/EPiAbstractions.zip')

