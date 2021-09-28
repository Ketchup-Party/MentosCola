# MentosCola
メントスコーラ

## unityyamlmerge
以下を`.git/config`に追記
```
[merge]
    tool = unityyamlmerge

    [mergetool "unityyamlmerge"]
    trustExitCode = false
    cmd = '<path to UnityYAMLMerge>' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```

### Windowsのパスの例
`C:/Program Files/Unity/Hub/Editor/2021.1.22f1/Editor/Data/Tools/UnityYAMLMerge.exe`

### macのパスの例
`/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge`
