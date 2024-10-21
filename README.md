AnimalSurgicalSImulator - LuxMedi
========

![image](https://github.com/user-attachments/assets/c98c24b1-b771-4f1c-8da2-76111efd0ee4)


**사용 기술**

- Unity
- C#
- XR Interaction Toolkit 
- Hand Tracking
- Shader
- VR

## Project LuxMedi

> **VR 수의 시뮬레이터**
>
> 수의과 학생 및 의사들을 타겟으로 하여 핵심역량을 기르고 실습 표본 부족에 의한 문제점을
>
> VR 시뮬레이터 내에서 실제 수술 환경을 재현하여 몰입도 높은 경험을 제공하기 위한 프로젝트 입니다.
---
## **Hand Tracking 을 사용한 콘텐츠**
>
> VR의 컨트롤러가 아닌 **Hand Tracking** 을 사용하여 사용하는 수의사 및 교육생들에게
>
> 실제와 같은 경험을 선사해 주기 위해 채택된 기술입니다.
---
## 개발 과정

> **구현 기능**
>- Hand Tracking (그랩 및 상호작용)
>- BHaptics (햅틱 반응)
>- Cross Section (쉐이더를 활용하여 크로스 섹션 구현 )
>- 의료 도구 상호작용 (메스,클램프,드릴)
>- Task (절차 진행을 위한 UI 및 사용자 유도)
>- 기초 술기 (손 씻기, 주사 바늘 삽입 술기)
---
### 1. Soket
> 기존의 XR ToolKit의 그랩 기능을 사용하여 오브젝트를 집고 상호작용을 하려고 했으나
>
> 직접 집고 상호작용하는 부분에 있어서 오류가 생거 사용자 손에 SoKet 을 넣고 활용하여
>
> 오브젝트를 집고 활용할 수 있게 제작하였습니다.

---
### 2. Task
> 실제 의사들이 시행하는 술기같은 경우 절차에 따라 진행되는 경우가 많습니다.
>
> VR 환경에서 의사들은 절차를 익히며 경험하는것이 중요하다고 판단하여
>
> Task 시스템을 사용하여 현재의 술기가 무엇이고 해당 술기의 절차를 한단계씩
>
> 진행해야지만 다음 단계로 넘어갈수 있게 제작하였습니다.

---
### 3. BHaptics
> BHaptics 의 Haptic Gloove 라는 장비를 사용하여 핸드트래킹시
>
> 착용한 장비에 햅틱이 오는 인터렉션을 설정하였습니다.
>
> 이러한 외부 장비를 통해 실제 물체를 잡고 움직이는 듯한 경험을 제공하기위해 구현하였습니다.

---
### 4. Base Skil

![image](https://github.com/user-attachments/assets/77d99fff-88b8-4ee5-b818-cf16ce536e1a)
![image](https://github.com/user-attachments/assets/812e002c-e7b4-4642-a0f3-e26bc2e9f6fe)

> 수술전의 기초적인 술기를 다루는 콘텐츠도 제작하였습니다.
>
> 현재는 손씻기 술기와 카테터 삽입 술기가 제작이 되어 있는 상태이며
>
> 실제 수술에서 의사들의 움직임과 손을 참고하여 구현하였습니다.

### 5. Anatomy
![image](https://github.com/user-attachments/assets/8d93eb4f-03ea-4ee2-b76a-e67ac615dffa)![image](https://github.com/user-attachments/assets/6f1f97b7-8bc3-41c8-bf24-c97e6478afcd)

> 개 모델링의 해부 구조를 보기 위해 Anatomy 콘텐츠를 제작하였습니다.
>
> 해당 개 모델링의 피부,근육,혈관,장기를 선택하여 볼 수 있고
>
> 3면에 위치한 면을 잡고 움직여 개의 단면부를 확인할 수 있게 제작하였습니다.

