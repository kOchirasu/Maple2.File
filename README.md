Maple2.File
===============
Strongly typed MapleStory2 m2d file parsing

### xblock Parsing Example:
```csharp
using var reader = new M2dReader(EXPORTED_PATH);
var parser = new XBlockParser(reader, index);
parser.Include(typeof(ISpawnPoint));
parser.Include(typeof(IMS2TriggerObject));
parser.Include(typeof(IPortal));
...

var results = new Dictionary<string, MapEntityMetadata>();
parser.Parse((xblock, entities) => {
    var metadata = new MapEntityMetadata();
    foreach (IMapEntity entity in entities) {
        switch (entity) {
            case ISpawnPointPC spawnPoint:
                ...
            case ISpawnPointNPC npcSpawnPoint:
                ...
            default:
                ...
        }
    }
    results[xblock] = metadata;
});
```
