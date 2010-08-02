version = File.read(File.expand_path("../VERSION",__FILE__)).strip
Gem::Specification.new do |spec|
	spec.platform    = Gem::Platform::RUBY
	spec.name        = 'epiabstractions'
	spec.version     = version
	spec.files = Dir['lib/**/*'] + Dir['docs/**/*']
	spec.add_dependency('castle.core','= 1.2.10.0')
	spec.add_dependency('castle.dynamicproxy2','= 2.1.0.0')
	spec.summary     = 'EPiAbstractions'
	spec.description = 'EPiAbstractions provides facades for many of the classes in EPiServers products which enable its users to decouple their code from the concrete implementations and thereby gaining the ability to unit test code that otherwise would depend on the concrete implementations.'
	spec.author = 'Joel Abrahamsson'
	spec.email             = 'mail@joelabrahamsson.com'
	spec.homepage          = 'http://epiabstractions.codeplex.com'
end