## To the developer reading this

I've applied for the role of Game Systems Engineer today. The very last step of the application had me include a link to a working system. I will be upfront - I scrambled with this one. I can't really afford to spend more time on applications than I already have, at least at this moment - and my last bit of public facing code that doesn't have obvious shortcuts and cut corners is from *five years ago*.

So I have decided to share the save system I worked on over two evenings last week, because it is *the most recent*, and is representative of how my code looks like when I just do it for myself and want something done.

`SaveManager` is a simple component that lets me loop through IStateful objects and save their state into a ScriptableObject-based save, and restore the state from those saves whenever I need to skip to a particular part of the game's narrative.

I am aware that it is:
- Undocumented
- Relies on MonoBehaviour and ScriptableObject
- Has very suspicious double (!) nested classes that would probbaly be more useful as standalone files

If this somehow gets to the interview stage, I'm happy to talk over how I'd code things differently if this was a team effort / long-term project.

If you're looking for another code sample something that's well documented, tested, and meant to be used by others, but is five years old, [this repository](https://github.com/mgackowski/mongodb-denormalizer) is a much better example.

Mikolaj "Nick", 01/05/2023
