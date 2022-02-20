# GameJam

Feb 20th 12:00PM => Feb 27th 12:00PM

## Tools

Tools used in this project:

### Game creation.
    1 - Unity ver 2020.3.20f1
    2 - C#
    3 - Gimp or Photoshop (2D art)
    4 - Blender (3D art)

### Support

    1 - GitHub
    
### Standard

#### 1. C# Style Standard to make the code more readable and make bugfixing easier
    
        a - "private" var => _privateVariable
        b - "public" var => PublicVariable
        c - "serializedfield" => serializedVariable
        d - Keep lines clean, push brackets to the next line.
        e - Nested "if" => "if" Guards
            from:
            if(a) 
            {
              if(b)
              {
                if(c)
                {
                  DoIt();
                }
              }
            }
            
            to:
            if(!a)
              return
            if(!b)
              return
            if(!c)
              return
            DoIt();

#### 2. GitFlow

GitFlow is a workflow that will helps in keeping branching in order and keeping track of the project's progress.

![GitFlow](https://user-images.githubusercontent.com/71270277/154837486-1b541524-f8f7-4dd4-9154-c43df946b240.png)
      
      release - Keep all the realase in the same branch
      main - Version of reference
      develop - Starting from main, where all the new feature are integrated
      feature - Create a new branch for each feature
      
## Ideas

### 1 - Gravity switch and camera rotation.
    a - Pending traps
    b - Water or obastacles that moves around the map blocking passages
    c - Apply gravity switch also to enemy to kill or zone-out them
    d - Disabling controls with a particular gravity switch
    
### 2 - 
