require 'fileutils'

puts '> Advent Of Christmas Copy'

def update_file(file_name, id)
    text = File.read(file_name)
    new_contents = text.gsub('DayX', "Day#{id}")
    
    File.open(file_name, "w") {|file| file.puts new_contents }
end

if ARGV.length == 0
  puts '  [X] No id specified'
  return
end    

id = ARGV[0]
if id.to_i < 1 || id.to_i > 25
  puts '  [X] Invalid id specified (Must be between 1 and 25)'
  return 
end

source = 'DayX'
destination = "Day#{id}"

if Dir.exists?(destination)
  puts "  [X] Directory 'destination' already exists"
  return
end

puts "  [ ] Copying template to '#{destination}'"
FileUtils.cp_r source, destination

puts '  [ ] Renaming Files'
FileUtils.mv("#{destination}/DayX.csproj", "#{destination}/Day#{id}.csproj")
FileUtils.mv("#{destination}/DayX.cs", "#{destination}/Day#{id}.cs")

puts '  [ ] Update Files'
update_file("#{destination}/Program.cs", id)
update_file("#{destination}/Day#{id}.cs", id)

puts '> Completed!'
