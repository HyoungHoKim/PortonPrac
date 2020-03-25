# PortonPrac



### LOD GROP

-----

Component -> Rendering -> LOD Group :  거리에 따라 로드 되는 LOD를 변경, 부하를 줄여줄 수 있다. 

### Animation

---

- Animator : Mecanim Type
  - Mecanim (Visual Editor)
    - Generic : Humeroid를 제외한 모든 GameObject
    - Humeroid : 이족 보행을 하는 GameObject, Retargeting 기능 제공 
    - 애니메이션 파일을 보면 Loop Time으로 뜸 
- Animation : Legacy Type 
  - Legacy
    - Full Code : 모두 코드로 처리, 속도가 빠름 
    - 애니메이션 파일을 보면 Wrap mode로 뜸 

- 두가지 타입은 호환이 안됨 
  - Tip : Inspector -> Right Click -> Debug -> Regacy uncheck, 단 모델파일과 정확히 맞아야만 사용 가능  

### RigidBody

---

- Drag : 직진 상의 마찰계수 
- Is Kinematic : 물리 엔진 연산을 하지 않음, 직접 물리연산을 할 때 씀
- Interpolate : 떨림현상 보장, 과거 프레임을 가지고 예상으로 보정
- Collision Detection : 충돌 감지 연산
  - Continuous : 프레임 보다 더 잘게 연속적으로 감지, 부하가 커짐  
- Constraints : position, rotation 좌표 중 원하는 값 연산을 하지 않음 

### Code Scriping

----

- Start()와 Awake()는 비슷하지만 Start()함수를 쓰게되면 어떤 스크립트가 먼저 실행되는지 모르기 때문에 Awake()를 쓴다. Awake()는 모든 Start()함수 앞에 실행, 또한 Script를 비활성화 해도 Awake()는 실행됨, Awake() 실행 우선수위를 설정하는 것이 가능(Project Setting -> Script Execution Order), 또한 Awake()는 코루틴 함수로 호출x, 일반적으로 초기화할 때 씀  
- Fixed Update()의 주기를 바꾸는 것이 가능, Project Setting -> Time -> Fixed TimeStep
- Vector3.forward = Vector3(0, 0, 1)
- Vector3.right = Vector3(1, 0, 0)
- Vector3.up = Vector3(0, 1, 0)
- Vector3.one = Vector3(1, 1, 1)
- Vector3.zero = Vector3(0, 0, 0)

### 발사 종류

---

- Projectile (발사체)
- Raycasting 
- if (Input.GetMouseButtonDown(0)) // 0 : Left Mouse Btn, 1 : Right Mouse Btn, 2 : Middle Button



### Sound

----

- AudioListner : 소리를 듣는 컴포넌트, 보통 main camera에 있다.
- AudioSource

### 총구 화염

----

- Muzzle Flash
- particle
- Mesh

