def point_convert(keynote_pos_x: int, keynote_pos_y: int, size_x: int, size_y: int):
    global SCREEN_SIZE_X, SCREEN_SIZE_Y
    unity_pos_x = -(SCREEN_SIZE_X / 2) + keynote_pos_x + size_x / 2
    unity_pos_y = (SCREEN_SIZE_Y / 2) - keynote_pos_y - size_y / 2
    return (unity_pos_x, unity_pos_y)


if __name__ == '__main__':
    SCREEN_SIZE_X = 1920
    SCREEN_SIZE_Y = 1080
    while True:
        keynote_pos_x = input("请输入Keynote中物体的横坐标：")
        keynote_pos_y = input("请输入Keynote中物体的纵坐标：")
        size_x = input("请输入物体的长度：")
        size_y = input("请输入物体的宽度：")
        keynote_pos_x = int(keynote_pos_x)
        keynote_pos_y = int(keynote_pos_y)
        size_x = int(size_x)
        size_y = int(size_y)
        (unity_pos_x, unity_pos_y) = point_convert(keynote_pos_x, keynote_pos_y, size_x, size_y)
        print("Unity2D中物体的横坐标为：" + str(unity_pos_x))
        print("Unity2D中物体的纵坐标为：" + str(unity_pos_y))
        print()
